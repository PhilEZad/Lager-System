ALTER TABLE CategoryTable
RENAME COLUMN Id to CategoryId,
RENAME COLUMN Name to CategoryName;

ALTER TABLE ItemTable
RENAME COLUMN Id to ItemId,
RENAME COLUMN Name to ItemName,
RENAME COLUMN Location to ItemLocation,
RENAME COLUMN Status to ItemStatus,
RENAME COLUMN Category to ItemCategory;