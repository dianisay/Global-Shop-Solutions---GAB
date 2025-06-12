Program.Sub.Preflight.Start

' Load external shared functions or utilities from library 450000.lib
Program.External.Include.Library("450000.lib")

Program.Sub.Preflight.End

Program.Sub.Main.Start

' Configure UI measurements to use Pixels instead of Twips
Function.Intrinsic.UI.UsePixels

' Below are some alternate or previously used methods for syncing Work Order data.
' These are currently commented out for reference or testing purposes:

' Manually add a row to DataTable 450000 with WO Number, Suffix, and Status (A for Active, H for History)
' F.Data.DataTable.AddRow("450000","MODE",7,"WONum","001112","WOSuffix","001","ActOrHist","A")

' Call custom sync subroutine for library 450000
' F.Intrinsic.Control.CallSub(450000Sync)

' Alternate sync using CallWrapperSync — general-purpose sync wrapper
' F.Global.General.CallWrapperSync(450000,"7!*!001112!*!001!*!A")

' Another general-purpose sync for module 900100 — Work Order details? Steps?
' F.Global.General.CallWrapperSync(900100,"001112!*!001!*!001811")

' Main active function call: BIO-specific wrapper sync
' This is the key logic in the script — it likely sends WO number (001112), suffix (001), and operation (001811)
' to a backend BIO process for sync or validation.
F.Global.General.CallWrapperSyncBIO(900100,"001112!*!001!*!001811")

Program.Sub.Main.End

' Metadata section automatically managed by GAB
Program.Sub.Comments.Start
${$5$}$20.1.9133.25878$}$1
${$6$}$tsmith$}$20250311134106905$}$xqPbj9atw05FglvzeFsZ9cqXP+qvG6tXBpEKNTgypcDe1xT+mZrH56av3nsyMc8cjTVYSf6K8lM=
${$7$}$File Version:1.1.20250311184106.0
Program.Sub.Comments.End
