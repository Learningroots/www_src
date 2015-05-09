
SELECT * FROM dbo.LocaleStringResource WHERE ResourceName LIKE '%.sku%' AND ResourceValue LIKE '%sku%'
--UPDATE dbo.LocaleStringResource SET ResourceValue = REPLACE(ResourceValue, 'SKU', 'Code') WHERE ResourceName LIKE '%.sku%' AND ResourceValue LIKE '%sku%'