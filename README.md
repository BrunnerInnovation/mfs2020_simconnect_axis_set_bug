# mfs2020_simconnect_axis_set_bug
Minimal VS2019 C# demo showing the bug occuring when using SimConnect AILERON_SET together with a USB rudder pedal

# Situation
A generic USB HID input device is used to control the rudder in MFS 2020.
Using the SimConnect API, AILERON_SET is used to send axis data for yoke input.

The USB input for Rudder forcefully centers the Aileron axis in the simulation, overriding the SimConnect input.
No USB device for Elevator or Aileron is connected.
