Exercise 1
Modify this example to say “Hello [User]!”

GAB programs can be triggered throughout the Global Shop system when “hooks” are triggered in normal program or screen operations. Program data is passed to the GAB Executer and GAB-modified data can optionally be passed back to the calling program. A hook is simply a place in the code of the standard system that allows a GAB program to be launched and is referenced by a hook number. Some hooks are process hooks; they are fired before or after a particular action is taken by the system (ex. when a quote is won and converted to a sales order, when a prospect is converted to a customer, or when a sales order is invoiced). Other hooks are event hooks and are fired when a particular event is triggered by the user. Some examples of event hooks are when a button is clicked or when a part is selected from a browser or manually entered. It is possible to trigger more than one GAB program from a single hook.
Hook sequences can be fired either synchronously or asynchronously. With asynchronous execution, the calling program does not wait for the GAB program to finish before resuming its own execution. With synchronous execution, the calling program waits for the GAB program to finish before resuming its own execution; this mode allows GAB to interact with the calling program.
“GAB Script Hook Maintenance” – 10 Minutes
GAB Script Hook Maintenance is the program where users assign GAB programs to hook sequences. It is launched from the following menu path: System Support > Administration > GAB Script Hook Maintenance and is pictured below:
 
Exploratory Script
The exploratory script is a standard GAB program that allows a user to view information on how and from where the hook was initiated, as well as the data passed from a core screen to a GAB program. The exploratory script can be attached to a hook sequence by using the binoculars icon in GAB Script Hook Maintenance. Caller parameters are referenced within a GAB program using the Variable.Caller namespace, while passed data items are referenced by ID using the Variable.Passed namespace. When this script is triggered, it brings up a Caller Information screen that includes looks like this:
 
Searching for GAB Hooks
Locating a Screen Name
Screen names are found in the lower left-hand corner of a core screen in the highlighted area below. For the sake of this example, we are using “Supply & Demand”. Go to Inventory > View > Supply and Demand and locate “INS500” as shown below.
 
In order to attach a GAB Script to a screen, open GAB Script Hook Maintenance and find all hooks on the screen you are going to be attaching the script to. This can be accomplished by using the search area at the bottom of the browser window when you click the browser button next to the Hook field. The best way to retrieve a list of all the hooks available to a screen is to configure the screen as below:
 
Then click “Filter Resultset”.
The specific hook that we are looking for is the “Populate” hook. This hook loads when the screen is populated. For this example, that is hook number 14045. Select hook 14045.
 
Now we can create a new hook sequence and attach the screen wizard to it. Click “New Seq”.
 
Use one of the three buttons (Magnifying Glass, Binoculars or Wizard Hat) to select a GAB script to attach to the hook. The three buttons correspond to “Opening File Explorer to select a specific GAB script”, “Exploratory script”, and “Screen Wizard” from left to right.
Click “Save Seq”. The GAB script selected is now tied to the GAB hook. To refresh GAB hooks, close out of the program handling the screen that is being modified and relaunch it.
Exercise 2
Attach Exercise2.g2u to Hook 16670 and find the Passed Variables for the Customer, Date Closed, and Router textboxes using the GAB Debugger.
 
Changing Data in a Calling Program
When changing data in a calling program, you use the V.Passed library and write information to the variables there. This can be done with the “.Set” command or by passing the Passed variables into return variable slots on functions.
Exercise 3
Attach Exercise3.g2u to Hook 10210 and overwrite Passed Variables for Alt Price 2 to increase its value by 5%, Alt Price 3 to decrease its value by 10% and Alt Price 4 to decrease its value by 25%.
 
Incorporating Looping
When we incorporate looping in GAB, we must determine 3 things: what is our start point, what is our end point, and how much we need to increment. In most cases, you will need to increment by a value of 1. There will be some cases where the end point of a loop is not defined by a value we can access, but by something we have to check each time the loop continues. For most cases, a For loop will be satisfactory for accessing data, processing data or doing repeat actions.
In cases where a check must be done to proceed through an iteration of a loop, a DoUntil or Do loop can be used.
Exercise 4
Run Exercise4.g2u and edit it to write out a list of Inventory parts that are flagged as inactive in one string value to a textbox ordered alphabetically.
 
Forms Designer Introduction
The GAB forms designer will allow you to design forms that your GAB program will use to show and/or collect data. Normally, these are the portions of the program that your users, or audience, will interact with. It is launched from within the GAB Code Editor (IDE) by clicking on the painter’s palette icon on the toolbar.
The basic process usually consists of creating a form (or window), organizing controls within the form, and defining properties and events on these controls. Some of the controls supported are labels, text boxes, drop down lists, radio buttons, check boxes, grids, and buttons. This is not a comprehensive list, as many more controls are available.
 Form Control Integration
Best practices dictate that forms should be named with a descriptive name that includes a “F_” prefix.
For example, a form which includes additional part metadata may be titled, F_PartMeta.
Controls should also be named with descriptive names that include a prefix based on the type of control.
Here is a short list of control and prefix examples:
 
Some common form control properties include caption/text, value, enabled, and visible. These methods can be set within the code as follows: GUI.F_Form.txtTextbox.Text(“Hello world!”) or GUI.F_Form.chkCheckbox.Value(1).
Similarly, the same form control properties can be referenced within the code as follows:
Variable.Screen.F_Form!txtTextbox.Text or Variable.Screen.F_Form!chkCheckbox.Value
Initial values for controls can either be set in the Forms Designer using the DefaultValue property or within the code using the text or value properties as described above. Controls can be grouped by specifying a non-zero control group ID. All controls in a group can be reset to their default values with one command:
GUI.F_Form..ClearGroup(Control Group ID)
Exercise 5
Open Exercise5.g2u and open the forms designer. Observe the controls created and add a drop down-list filled with 5 values of your choosing. Default the drop-down list to List Index 3 before showing the screen.
 
Exercise 6
Open Exercise6.g2u and observe how the script reads values from the form using V.Screen. Add an additional text box to the screen for Height, label it, and include it in the calculation in the button click subroutine to calculate a new text box for Volume using “Length x Width x Height”.
 

