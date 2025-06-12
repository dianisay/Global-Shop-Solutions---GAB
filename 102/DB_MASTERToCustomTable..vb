'This script queries the first 10 inventory items from INVENTORY_MSTR where QTY_ONHAND = 0, and inserts select data into a custom table GCG_CUSTOM_TABLE. It uses ExecuteAndReturn to get records, splits the results using defined delimiters, and inserts trimmed and cleaned values into the custom table.

'Execute - Insert, Update, Delete statements
'ExecuteAndReturn - Select statements
	'*!* is the inner delimiter
	'#$# is the outer delimiter
	

Program.Sub.Preflight.Start
' No preflight logic defined for this script
Program.Sub.Preflight.End

Program.Sub.Main.Start

' Use Pixels instead of Twips for any UI layout settings
Function.Intrinsic.UI.UsePixels

' Declare local variables
V.Local.sSQL.Declare        ' Used for SQL queries and dynamically built SQL statements
V.Local.iCnt.Declare        ' Counter for looping through result rows
V.Local.sRowSplit.Declare   ' Array used to hold column values after splitting a row
V.Local.sRet.Declare        ' Array used to hold all returned rows

' Optional override to force a specific company code (commented out)
' F.Global.General.OverrideCompany(PLA)

' Optional test for common connection (commented out)
' F.ODBC.Connection!comm.OpenCommonConnection
' F.ODBC.Connection!comm.Close

' Connect to the company database
F.ODBC.Connection!con.OpenCompanyConnection

    ' Query first 10 items from INVENTORY_MSTR where quantity on hand is zero
    F.ODBC.Connection!con.ExecuteAndReturn(
        "SELECT TOP 10 PART, LOCATION, CODE_ABC, PRODUCT_LINE, DESCRIPTION FROM INVENTORY_MSTR WHERE QTY_ONHAND = 0", 
        V.Local.sSQL
    )

    ' Split the returned rows using the outer delimiter #$#
    F.Intrinsic.String.Split(V.Local.sSQL, "#$#", V.Local.sRet)

    ' Loop through each row
    F.Intrinsic.Control.For(V.Local.iCnt, V.Local.sRet.UBound)
    
        ' Split row into fields using inner delimiter *!*
        F.Intrinsic.String.Split(V.Local.sRet(V.Local.iCnt), "*!*", V.Local.sRowSplit)
        
        ' Build an INSERT statement using trimmed and cleaned values
        F.Intrinsic.String.Build(
            "INSERT INTO GCG_CUSTOM_TABLE (PART, LOC, PUSER1, PUSER2) VALUES ('{0}', '{1}', '{2}', '{3}')",
            V.Local.sRowSplit(0).Trim,        ' PART
            V.Local.sRowSplit(1).Trim,        ' LOC
            V.Local.sRowSplit(3).Trim,        ' PRODUCT_LINE
            V.Local.sRowSplit(4).PSQLFriendly ' DESCRIPTION (make SQL-safe)
            ,
            V.Local.sSQL                      ' Reusing sSQL to hold the INSERT statement
        )
        
        ' Execute the insert statement
        F.ODBC.Connection!con.Execute(V.Local.sSQL)
        
    F.Intrinsic.Control.Next(V.Local.iCnt)

' Close the connection after insertions
F.ODBC.Connection!con.Close

Program.Sub.Main.End

' GAB metadata (auto-generated)
Program.Sub.Comments.Start
${$5$}$20.1.9133.25878$}$1
${$6$}$tsmith$}$20250311103445325$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tXBpEKNTgypcBA/CVYmkl+/lKCcNPT+or9AAeonY/zxQE=
${$7$}$File Version:1.1.20250311153445.0
Program.Sub.Comments.End

