# ClickHouseDDLExpression
### Генерация DDL выражений для СУБД ClickHouse.

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
