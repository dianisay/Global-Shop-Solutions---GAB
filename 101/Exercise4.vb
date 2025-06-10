Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start
'GAB training
'Exercise 4

' Goal: Return a structured list of all parts in alphabetical order

V.Local.sSQL.Declare 'contains the rows from the SQL query.
V.Local.iCnt.Declare 'the counter (starts at 0).
V.Local.sMsg.Declare
V.Local.sRowSplit.Declare 'holds the whole row divided, notice it contains all of the elements.

' Step 1: Query all parts in alphabetical order
V.Local.sSQL.Set("SELECT PART FROM V_INVENTORY_MSTR ORDER BY PART;")

' Step 2: Run the query
'This opens a connection, runs the query, and stores the result back into V.Local.sSQL.
F.ODBC.Connection!con.OpenCompanyConnection
F.ODBC.Connection!con.ExecuteAndReturn(V.Local.sSQL, V.Local.sSQL)
F.ODBC.Connection!con.Close
'ALWAYS OPEN AND CLOSE IMMEDIATLY!!!!!!!!

' Step 3: Split the result into rows
F.Intrinsic.String.Split(V.Local.sSQL, "#$#", V.Local.sSQL)

' Step 4: Loop through each row and build the message
' “Loop through each row in the result.”
F.Intrinsic.Control.For(V.Local.iCnt, V.Local.sSQL.UBound)  'V.Local.sSQL.UBound is the upper bound (last index) of the array V.Local.sSQL, which contains the rows from the SQL query.
	
	'This splits the current row (like "PART123*!*ExtraData") into pieces using the delimiter "*!*".
    F.Intrinsic.String.Split(V.Local.sSQL(V.Local.iCnt), "*!*", V.Local.sRowSplit) 
    	'The result is stored in V.Local.sRowSplit, which becomes an array.
		'V.Local.sRowSplit(0) will usually be the part number.
    
    F.Intrinsic.String.Build("{0}{1}{2}", V.Local.sMsg, V.Local.sRowSplit(0), V.Ambient.NewLine, V.Local.sMsg)
   'This builds a new string by combining:
		'{0}The current message (V.Local.sMsg)
		'{1}The part number (V.Local.sRowSplit(0))
		'{2}A new line (V.Ambient.NewLine)
	'The result is stored back into V.Local.sMsg
	
F.Intrinsic.Control.Next(V.Local.iCnt) 'This moves to the next item in the loop.

' Step 5: Show the result
F.Intrinsic.UI.MsgBox(V.Local.sMsg, "Parts List")

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250610135826394$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKVxCCg+EHxqFCaZpIx8+RydOBHsZ2l3OM=
${$7$}$File Version:1.1.0.1
Program.Sub.Comments.End
