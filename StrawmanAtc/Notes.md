# ATC API: Strawman design notes

## Client brief

I want a web service where I can track the operations of all my ATC installations.

I want see where all the drones are.

I want to see all their observations correctly located on a map.

## Design analysis

Things in the system are:

- Root (owner of ATC)
- ATC installations (owner of drones)
	- Location
- Drones
- Data collections; always tagged with spacetime
	- Photogrammetry data (image)
	- Atmospheric data (e.g. wind speed, temperature, pressure)
	- Drone state (location, heading, airspeed, battery)
- Missions
	- Takeoff
	- Landing
	- Grounded (e.g. charging? offline maintenance?)
	- Transit
	- Loiter

## Proposed hierarchy

- root:
	- ATCs: []
		- ID
		- Location
		- Drones:[]
			- ID
			- Mission:[]
				- Action: ( takeoff, landing, grounded, transit, loiter )
				- Spacetime objective
			- Observations:[]
				- Spacetime
				- Kind: ( photogram, atmospheric, dronestate )
				- { data }