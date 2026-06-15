WITH UnionAllTables AS (
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_1]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_2]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_3]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_4]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_5]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_6]
    UNION ALL
    SELECT [Unique_ID], [Upload_UUID], [Upload_Time], [Verified_UUID], [Verified_Time], [Verification_Status] FROM [dbo].[BattaramullaFile_7]
),
UnionAllTables2 AS (
    SELECT DOCUMENTID, DocumentUID FROM [C514C7EC-DAA2-4DA5-8E82-98901BE1671C]
    UNION ALL
    SELECT DOCUMENTID, DocumentUID FROM [8F84E32E-C274-4602-B84F-636B05DEC873]
    UNION ALL
    SELECT DOCUMENTID, DocumentUID FROM [D8276AD1-1835-4E12-A1D0-DFF90D38F89B]
    UNION ALL
    SELECT DOCUMENTID, DocumentUID FROM [39FED7CB-4485-4F82-AEC8-86C5FFA66606]
    UNION ALL
    SELECT DOCUMENTID, DocumentUID FROM [324BE33C-7FE8-4A4E-8153-8C09D755EA37]
	UNION ALL
    SELECT DOCUMENTID, DocumentUID FROM [906F9D91-3CA7-49B5-82B9-4AD4CDF9ECA6]
),
MatchedDocs AS (
    SELECT 
 u.Unique_ID,
        u.Upload_UUID,
        u2.DocumentID,
        u.[Upload_Time],
        u.Verified_UUID,
        u.Verified_Time,
  U.Verification_Status
    FROM UnionAllTables u
    INNER JOIN UnionAllTables2 u2 
        ON u.Unique_ID = u2.DocumentUID where U.Verification_Status = 'Verified'
)

--Run 1st
--UPDATE EWR
--SET EWR.ApprovedUserID = MD.Verified_UUID
--FROM [Enadoc12688B9B38A4000].[dbo].[EnadocWorkflowReport] EWR
--INNER JOIN MatchedDocs MD
--    ON EWR.DocID = MD.DocumentID WHERE MD.DocumentID IS NOT NULL and MD.Verified_UUID is not null

--Run 2nd
--UPDATE EWR
--SET EWR.ApprovedDate = DATEADD(MINUTE, -330, MD.Verified_Time)
--FROM [Enadoc12688B9B38A4000].[dbo].[EnadocWorkflowReport] EWR
--INNER JOIN MatchedDocs MD
--    ON EWR.DocID = MD.DocumentID WHERE MD.DocumentID IS NOT NULL and MD.Verified_Time is not null
 
 --Run 3rd
--UPDATE EWR
--SET EWR.Status = CASE 
--                    WHEN MD.Verification_Status = 'Verified' THEN 1 
--                    ELSE 0 
--                 END
--FROM [Enadoc12688B9B38A4000].[dbo].[EnadocWorkflowDocumentStatus] EWR
--INNER JOIN MatchedDocs MD
--    ON EWR.DocumentID = MD.DocumentID WHERE MD.DocumentID IS NOT NULL and MD.Verification_Status is not null