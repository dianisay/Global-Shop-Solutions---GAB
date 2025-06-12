'This GAB script loads order line data (V_ORDER_LINES) and inventory data (V_INVENTORY_ALL), then performs a left join to enrich order lines with inventory fields (like on-hand quantity and product line). The result is saved into a new DataTable called dtSOs.

Program.Sub.Preflight.Start
' No preflight logic needed
Program.Sub.Preflight.End

Program.Sub.Main.Start

' Allows you to use pixels for GUI sizing and positioning instead of Twips
Function.Intrinsic.UI.UsePixels

' Open a connection to the company database
F.ODBC.Connection!con.OpenCompanyConnection

	' Query order line data: includes ORDER_NO, a shortened ORDER_LINE, PART, LOCATION, and quantities
	F.Data.DataTable.CreateFromSQL("dtOrderLines","con",
		"Select ORDER_NO, Left(RECORD_NO,3) as ORDER_LINE, PART, LOCATION, QTY_ORDERED, QTY_BO from V_ORDER_LINES",
		True)

	' Query inventory data: includes PART, LOCATION, QTY_ONHAND, PRODUCT_LINE, and DESCRIPTION
	F.Data.DataTable.CreateFromSQL("dtParts","con",
		"Select PART, LOCATION, QTY_ONHAND, PRODUCT_LINE, RTRIM(DESCRIPTION) as DESCRIPTION from V_INVENTORY_ALL",
		True)

' Close the company connection after data has been loaded
F.ODBC.Connection!con.Close

' Perform a Left Join using LINQ:
'   - Join dtOrderLines (aliased as LINE) to dtParts (aliased as PART)
'   - Join on: PART and LOCATION
'   - Select specific fields from each table and alias them appropriately
F.Data.Linq.Join(V.Enum.LinqJoinType!LeftJoin,V.Enum.LinqSourceType!DataTable,"dtOrderLines*!*LINE",V.Enum.LinqSourceType!DataTable,"dtParts*!*PART","LINE.PART = PART.PART and LINE.LOCATION = PART.LOCATION","LINE.ORDER_NO*!*LINE.ORDER_LINE*!*LINE.PART*!*LINE.LOCATION as LOC*!*LINE.QTY_ORDERED*!*LINE.QTY_BO*!*PART.QTY_ONHAND*!*PART.PRODUCT_LINE as PL*!*PART.DESCRIPTION as DESCR","","","LINE.ORDER_LINE asc","dtSOs",True)
'	V.Enum.LinqJoinType!LeftJoin,                 ' Type of join: Left Join
'	V.Enum.LinqSourceType!DataTable,              ' Left side source: DataTable
'	"dtOrderLines*!*LINE",                        ' Alias the order lines table as LINE
'	V.Enum.LinqSourceType!DataTable,              ' Right side source: DataTable
'	"dtParts*!*PART",                             ' Alias the parts table as PART
'	"LINE.PART = PART.PART and LINE.LOCATION = PART.LOCATION", ' Join condition
'	"LINE.ORDER_NO*!*LINE.ORDER_LINE*!*LINE.PART*!*LINE.LOCATION as LOC*!*LINE.QTY_ORDERED*!*LINE.QTY_BO*!*PART.QTY_ONHAND*!*PART.PRODUCT_LINE as PL*!*PART.DESCRIPTION as DESCR", ' Selected fields
'	"",                                           ' Group by (not used)
'	"",                                           ' Having (not used)
'	"LINE.ORDER_LINE asc",                        ' Sort order
'	"dtSOs",                                      ' Result table name
'	True                                          ' Clear result table first


' Open the debugger at this point (for testing or development use)
Function.Intrinsic.Debug.InvokeDebugger

' Halt execution here during debugging
Function.Intrinsic.Debug.Stop

Program.Sub.Main.End

Program.Sub.Comments.Start
${$5$}$20.1.9133.25878$}$1
${$6$}$tsmith$}$20250311130100866$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tXBpEKNTgypcCFaM3EBYlRMG9fZREXQ13PcmyAp9KIXUw=
${$7$}$File Version:1.1.20250311180100.0
Program.Sub.Comments.End
			
