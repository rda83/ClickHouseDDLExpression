# ClickHouseDDLExpression
Библиотека предназначена для генерации DDL выражений СУБД ClickHouse.

На данный момент позволяет сгенерировать выражение CREATE TABLE следующими способами:
 - использование fluent интерфейса;
 - с помощью анализа свойств и атрибутов класса. 

Текущая версия обладает следующими ограничениями:
 - поддерживается только MergeTree движок;
 - может генерировать только CREATE TABLE выражение;
 - ...

#### Пример использования #1 - анализ свойств и атрибутов класса:

##### DTO класс Aircraft:
```csharp
public class Aircraft
{
    [ColumnCompressionCodecZSTD(1)]
    [ClickHouseColumn(PrimaryKey = 1, NotNull = false, OrderBy = 1)]
    public string Model { get; set; }

    [ColumnCompressionCodecDoubleDelta]
    [ColumnCompressionCodecLZ4]
    public int AircraftRange { get; set; }

    [ColumnCompressionCodecDoubleDelta]
    [ColumnCompressionCodecLZ4]
    public int AircraftClass { get; set; }

    [ColumnCompressionCodecDoubleDelta]
    [ColumnCompressionCodecLZ4]
    public int Velocity { get; set; }

    [ColumnCompressionCodecZSTD(1)]
    public string Code { get; set; }
}
```
##### Логика генерации CREATE TABLE выражения:
```csharp
var builder = new CreateTableBuilder();           
string expressionText = builder.Build<Aircraft>(
    new CreateExpressionParameters()
    {
        DataBaseName = "AirDb",
    });
```
##### Результирующее выражение:
```sql
CREATE TABLE AirDb.Aircraft
(
    Model String NOT NULL CODEC(ZSTD(1)),
    AircraftRange Int32 NOT NULL CODEC(DoubleDelta, LZ4),
    AircraftClass Int32 NOT NULL CODEC(DoubleDelta, LZ4),
    Velocity Int32 NOT NULL CODEC(DoubleDelta, LZ4),
    Code String NOT NULL CODEC(ZSTD(1))
) ENGINE = MergeTree()
ORDER BY Model
PRIMARY KEY Model
SETTINGS index_granularity = 8192
```
#### Пример использования #2 - fluent интерфейс:
##### Логика генерации CREATE TABLE выражения:
```csharp
var createTableCommandBuilder = new CreateTableCommandBuilder();
var table = createTableCommandBuilder
    .SetDbName("JournalDB")
    .SetTableName("Events")
    .SetIsNotExists(false)
    .SetTableEngine(
        new TableEngineMergeTreeBuilder()
        .Build())
    .SetPartitioningKey(
        new PartitioningKeyValue(() => "toYYYYMM(TimeStamp)"))
    .AddColumn(
        new ColumnDescriptionBuilder()
            .SetColumnName("EventId")
            .SetDataType(new ClickHouseDataTypeInt64())
            .AddFieldCodec(new ClickHouseCompressionCodecLZ4())
            .SetIsNotNull(true)
            .SetOrderBy(0)
            .SetPrimaryKey(0)
            .Build())
    .AddColumn(
        new ColumnDescriptionBuilder()
            .SetColumnName("TimeStamp")
            .SetDataType(new ClickHouseDataTypeDateTime())
            .SetIsNotNull(true)
            .Build())
    .AddColumn(
        new ColumnDescriptionBuilder()
            .SetColumnName("TextMessage")
            .SetDataType(new ClickHouseDataTypeString())
            .AddFieldCodec(new ClickHouseCompressionCodecLZ4())
            .Build())
    .Build();
var сreateTableHandler = new CreateTableHandler();            
string commandText = сreateTableHandler.GetCommand(table);
```
##### Результирующее выражение:
```sql
CREATE TABLE JournalDB.Events
(
    EventId Int64 NOT NULL CODEC(LZ4),
    TimeStamp DateTime NOT NULL,
    TextMessage String NULL CODEC(LZ4)
) ENGINE = MergeTree()
ORDER BY EventId
PRIMARY KEY EventId
PARTITION BY toYYYYMM(TimeStamp)
```


