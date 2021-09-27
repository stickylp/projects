;Autonexus v1.4 + pot heal -script made by Sticky
;Should work on any 16:9 display 
#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
 ; #Warn  ; Enable warnings to assist with detecting common errors.

SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.
#MaxThreadsPerHotkey 2

nexusHotkey = R ; put your nexus hotkey here
potHotkey = {XButton2} ; heal/first pot hotkey here
calculatedHeight = 0 ; dont touch becouse it shouldnt matter
calculatedWidth = 0 ; dont touch becouse it shouldnt matter


if WinExist("RotMGExalt")
{
	WinGetPos,,, Width, Height
	calculatedHeight := 486
	calculatedWidth := 1571
	calculatedConst := (1908 - calculatedWidth)/100
	
	
	Gui, Add, Tab2,, AutoNexus|AutoHeal
	Gui, Add, Radio, vMyRadio, 20`%
	Gui, Add, Radio,, 30`%
	Gui, Add, Radio,, 40`%
	Gui, Add, Radio,, 50`%
	Gui, Tab, 2
	Gui, Add, Radio, vMyRadio2, 45`%
	Gui, Add, Radio,, 55`%
	Gui, Add, Radio,, 65`%
	Gui, Add, Button, default xm, OK  ; xm puts it at the bottom left corner.
	Gui, Show
	return

	ButtonOK:
	GuiClose:
	GuiEscape:
	Gui, Submit  ; Save each control's contents to its associated variable.
	Gui, Destroy

	if MyRadio = 1
	{
		nexusValue := 20 * calculatedConst + calculatedWidth
		nexusValueCeil := Ceil(nexusValue)
	}
	else if MyRadio = 2 
	{
		nexusValue := 30 * calculatedConst + calculatedWidth
		nexusValueCeil := Ceil(nexusValue)
		
	}
	else if MyRadio = 3 
	{
		nexusValue := 40 * calculatedConst + calculatedWidth
		nexusValueCeil := Ceil(nexusValue)
	}
	else if MyRadio = 4 
	{
		nexusValue := 50 * calculatedConst + calculatedWidth
		nexusValueCeil := Ceil(nexusValue)
	}
	else 
	{
		nexusValue := 30 * calculatedConst + calculatedWidth
		nexusValueCeil := Ceil(nexusValue)
	}

	if MyRadio2 = 1
	{
		potValue := 45 * calculatedConst + calculatedWidth
		potValueCeil := Ceil(potValue)
	}
	else if MyRadio2 = 2 
	{
		potValue := 55 * calculatedConst + calculatedWidth
		potValueCeil := Ceil(potValue)
	}
	else if MyRadio2 = 3 
	{
		potValue := 65 * calculatedConst + calculatedWidth
		potValueCeil := Ceil(potValue)
	}
	else 
	{
	}

	CustomColor := "000000"
	Gui +LastFound +AlwaysOnTop -Caption +ToolWindow
	Gui, Color, %CustomColor%
	Gui, Font, s25  ; Set a large font size (32-point).
	Gui, Add, Text, vMyText cLime, OFF
	WinSet, TransColor, %CustomColor% 200
	Gui, Show, x1100 y-5 NoActivate 
	
	^n::
	Toggle := !Toggle
	loop
	{
        	If not Toggle
	{
        	GuiControl,, MyText, OFF
		break
	}
	GuiControl,, MyText, ON
	
    	PixelGetColor, colorNexus, %nexusValueCeil%, %calculatedHeight%
	if ("0x545454" = colorNexus) {
		Send %nexusHotkey%
	}
	if ("0xE3E3E3" = colorNexus) {
		Send %nexusHotkey%
	}
	
	
	Sleep, 15 
}
return

}
else
{
	MsgBox Rotmg window not found, please check if your Rotmg window is called "RotMGExalt".
	ExitApp
}

Cooldown:
Cooldown := false
SetTimer, Cooldown, off
return