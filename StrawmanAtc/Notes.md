# ATC API: Strawman design notes

## Client brief

I want a web service where I can track the operations of all my ATC installations.

I want see where all the drones are.

I want to see all their observations correctly located on a map.

## Design analysis

Things in the system are:

- CTC (owner of ATC)
- ATC installations (owner of drones)
	- Location
	- ATC-Battery
	- Data blob store
- Drones
- Data collections; always tagged with spacetime
	- Photogrammetry data (image/blob)
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

## Proposed protocol

### Assumptions

- **Drone TX data is either "MAVlink-like", or "small" json, or "blob metadata".**
  The TX data is available effectively instantaneously at the ATC.
- **The ATC is exclusively responsible for determining when to report back to CTC.**
  The CTC must have some expectation of regular TX, so that it knows when to report
  an offline ATC.
- **The ATC has effectively unlimited persistent storage.** Therefore we can store
  complete operational history and the full data for even large data captures.

### ATC-issued requests

#### POST (PUT?) update:

- TX metadata
  - TXID: an identifier for the current transmission
  - Previous TXID: an identifier for the previous TX in sequence.
    *Logging, traceability, resync.*
  - Expected next transmission; or null if being shut down.
    *"Offline" detection for CTC.*
- Self-state:
  - location
  - identity
  - battery level and discharge rate
  - uptime
- Drone states[]:
  - latest navigation observation
  - new data
    - observation spacetime
    - payload | deferred-payload
- New available deferred payloads[]:
  - payload id *(i.e. "filename")*
  - payload kind *(e.g. MIME type)*

### CTC-issued requests

#### GET resync

- → ATC update model as above, but aggregate full history

*ATC is assumed to keep full records of update model data, since data is "small-ish".*

#### GET resync from previous (TXID)

- → ATC update model as above, aggregating starting from given TXID;
  or 404 Not Found if the TXID is not known to the ATC.

#### GET deferred payload (payload-id)

- → HTTP content

*Assumption: image data should be "large" and "rare", so the overhead of
potentially-many requests for a set of images is not a huge deal.*

#### POST Assign mission

- "mission specification model" TBC
- "estimated cost model" TBC

response

- isAccepted
- "accepted mission specification model" TBC
- "actual cost model" TBC