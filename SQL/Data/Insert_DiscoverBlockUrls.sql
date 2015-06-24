BEGIN TRAN

DECLARE @blockId INT
DECLARE @resourceName NVARCHAR(200)
DECLARE @resourceValue NVARCHAR(max)

SET @blockId = 0

--Block 1
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/companions'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 2
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/quran-fun'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 3
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/stories'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 4
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/games'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 5
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/gifts-novelties'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 6
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Url')
SET @resourceValue = N'/collections'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SELECT TOP 30 * FROM dbo.LocaleStringResource ORDER BY id DESC

--COMMIT TRAN
--ROLLBACK TRAN
