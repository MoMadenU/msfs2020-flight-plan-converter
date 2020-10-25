# msfs2020-flight-plan-converter

A small app that converts flight plan .fpl files you can download from SkyVector into 
MSFS 2020 .PLN files

## Releases and Download

The repo contains source code only
program zips releases are [here](https://github.com/MoMadenU/msfs2020-flight-plan-converter/releases)

## Components

Just a simple standalone Winforms app

## Install and Run

The full video showing install and run is [HERE]()

Go to the releases page [here](https://github.com/MoMadenU/msfs2020-flight-plan-converter/releases) to get the latest release
Unzip to a local folder

Go to SkyVector and create a flight plan.

Click the send plan to.. icon located at the Flight Plan panel at the top. It's the icon with the arrow
Choose .fpl from the left side panel of the popup
Choose Download Garmin .fpl file     

Double click FlightPlanConverter.exe app to bring up the converter
You have to enter a cruise altitude because sadly Garmin .fpl files do not contain altitude information

Click Choose File To Convert
Pick the .fpl you downloaded frm SkyVector
Click Open

The .fpl will get converted and you should now see a .PLN
file with the same root name as the .fpl in the same folder

Launch MSFS 2020, bitch about how long it takes to load.

Once loaded launch the freeflight map and pick a plane.
Click Load/save at the bottom or press the Space bar.

Navigate to the .PLN created by the converter
Click open.
You should see your plan loaded into MSFS 2020

The waypoints will load into all aircraft the have some form of FMS
including all the GX000.

Don't expect much more since all the real detail information is located in the .FLT file
I am working on being able to generate .FLT files from apps that can produce load sheets.

 





 
  


