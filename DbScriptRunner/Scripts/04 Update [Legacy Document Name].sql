UPDATE t
SET 
    t.[Legacy Document Name] = v.Doc_Name
FROM [IndexTbaleName] t
INNER JOIN (
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_1]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_2]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_3]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_4]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_5]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_6]
    UNION ALL
    SELECT [Unique_ID], [Doc_Name] FROM [dbo].[BattaramullaFile_7]
) v
    ON t.DocumentUID = v.Unique_ID;