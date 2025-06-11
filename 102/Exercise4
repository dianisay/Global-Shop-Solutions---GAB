Program.Sub.Preflight.Start
Program.Sub.Preflight.End

'Program.Sub.Main.Start

'Add a new field called PUSER3 (Char (30)) to GCG_CUSTOM_TABLE
'V.Local.sSQL.Declare(String)
'V.Local.sSQL.Set("ALTER TABLE GCG_CUSTOM_TABLE ADD PUSER3 CHAR(30);")

'F.ODBC.Connection!con.OpenCompanyConnection
'F.ODBC.Connection!con.Execute(V.Local.sSQL)
'F.ODBC.Connection!con.Close

'Program.Sub.Main.End
'----------------------------------------------------------------------------------------------------------------------------------------------------------------

'1. take the first 3 rows of "PART", "LOCATION" from INVENTORY_MST and paste it at "PART", "LOC"GCG_CUSTOM_TABLE

'Program.Sub.Main.Start

' Declare variables
'V.Local.sSQL.Declare 'contains the rows from the SQL query.

' Step 1: Query all parts in alphabetical order
'V.Local.sSQL.Set("INSERT INTO GCG_CUSTOM_TABLE (PART, LOC) SELECT PART, LOCATION FROM INVENTORY_MSTR LIMIT 3;;")

' Step 2: Run the query
'This opens a connection, runs the query, and stores the result back into V.Local.sSQL.
'F.ODBC.Connection!con.OpenCompanyConnection
'F.ODBC.Connection!con.Execute(V.Local.sSQL)
'F.ODBC.Connection!con.Close
'ALWAYS OPEN AND CLOSE IMMEDIATLY!!!!!!!!

'Program.Sub.Main.End

'-----------------------------------------------
'2. Make a code  that using the "PART", "LOC" stored at GCG_CUSTOM_TABLE, it goes to INVENTORY_MST and extracts WHO_CHG_LAST. Then, WHO_CHG_LAST at PUSER3

Program.Sub.Main.Start

' Declare variables
V.Local.sSQL.Declare 'contains the rows from the SQL query.

' Step 1: Query all parts in alphabetical order
V.Local.sSQL.Set("UPDATE GCG_CUSTOM_TABLE SET PUSER3 = (SELECT WHO_CHG_LAST FROM INVENTORY_MSTR WHERE INVENTORY_MSTR.PART = GCG_CUSTOM_TABLE.PART AND INVENTORY_MSTR.LOCATION = GCG_CUSTOM_TABLE.LOC) WHERE EXISTS (SELECT 1 FROM INVENTORY_MSTR WHERE INVENTORY_MSTR.PART = GCG_CUSTOM_TABLE.PART AND INVENTORY_MSTR.LOCATION = GCG_CUSTOM_TABLE.LOC);")

' Step 2: Run the query
'This opens a connection, runs the query, and stores the result back into V.Local.sSQL.
F.ODBC.Connection!con.OpenCompanyConnection
F.ODBC.Connection!con.Execute(V.Local.sSQL)
F.ODBC.Connection!con.Close
'ALWAYS OPEN AND CLOSE IMMEDIATLY!!!!!!!!

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250611141255360$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLJ3RbRWf/ZaPQ6DSkDNultlc82QteahW4E=
${$7$}$File Version:1.1.20250611191255.1
Program.Sub.Comments.End
