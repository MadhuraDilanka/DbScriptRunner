UPDATE t
SET 
    t.[Legacy Uploaded User] = v.Upload_UserID,
    t.[Legacy Verified User] = v.Verified_UserID
FROM [IndexTbaleName] t
INNER JOIN (
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_1]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_2]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_3]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_4]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_5]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_6]
    UNION ALL
    SELECT [Unique_ID], [Upload_UserID], [Verified_UserID] FROM [dbo].[BattaramullaFile_7]
) v
    ON t.DocumentUID = v.Unique_ID;