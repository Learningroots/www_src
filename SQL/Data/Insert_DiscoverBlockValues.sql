BEGIN TRAN

DECLARE @blockId INT
DECLARE @resourceName NVARCHAR(200)
DECLARE @resourceValue NVARCHAR(max)

SET @blockId = 0

--Title
SET @resourceName = 'Home.Discover.Banner.Title'
SET @resourceValue = N'Explore'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)


--Block 1
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Quran Fun'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 2
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Prayer & Dua'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 3
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Stories'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 4
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Games'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 5
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Gifts'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

--Block 6
SET @blockId = @blockId + 1

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Title')
SET @resourceValue = N'Collections'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SET @resourceName = CONCAT('Home.Discover.Block', @blockId, '.Subtitle')
SET @resourceValue = N'EXPLORE'
INSERT [dbo].[LocaleStringResource]([LanguageId], [ResourceName], [ResourceValue]) VALUES (1,@resourceName, @resourceValue)

SELECT TOP 30 * FROM dbo.LocaleStringResource ORDER BY id DESC

--COMMIT TRAN
--ROLLBACK TRAN
