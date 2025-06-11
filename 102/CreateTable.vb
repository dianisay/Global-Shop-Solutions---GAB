Program.Sub.Preflight.Start
Program.Sub.Preflight.End

Program.Sub.Main.Start

V.Local.sSQL.Declare

' Define the CREATE TABLE SQL statement
' The .Set() method for string variables in GAB scripting does not support multiline strings using triple quotes or line breaks as shown in your code. You must assign the SQL as a single-line string, or concatenate lines explicitly.
V.Local.sSQL.Set("CREATE TABLE GCG_CUSTOM_TABLE (PART CHAR(30), LOC CHAR(10), PUSER1 CHAR(50), PUSER2 CHAR(50));")

'Or, if you want to build it in parts:

'V.Local.sSQL.Set("CREATE TABLE GCG_CUSTOM_TABLE (")
'V.Local.sSQL.Append("PART CHAR(30), ")
'V.Local.sSQL.Append("LOC CHAR(10), ")
'V.Local.sSQL.Append("PUSER1 CHAR(50), ")
'V.Local.sSQL.Append("PUSER2 CHAR(50));")



' Open connection, execute SQL, and close connection
F.ODBC.Connection!con.OpenCompanyConnection
F.ODBC.Connection!con.Execute(V.Local.sSQL)
F.ODBC.Connection!con.Close

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$23.1.9243.18408$}$1
${$6$}$droldan$}$20250611093602369$}$B2femnEqbLfZe6KOMlAUIUDbLEceswGWHv6wtu8ZCLKybYYdFZycewcekOwUoHDlU2zGgsnXRMI=
${$7$}$File Version:1.1.20250611143602.1
Program.Sub.Comments.End
