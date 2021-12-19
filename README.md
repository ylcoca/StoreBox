# StoreBox
Insertion and retreival of orders and minimun width based on 

    1 photoBook consumes 19 mm of package width
    1 calendar — 10 mm of package width
    1 canvas — 16 mm
    1 set of greeting cards — 4.7 mm
    1 mug — 94 mm
	
From 1 to 4 mugs stacked count as single space of 94 mm

API endpoints

	Get order /api/Order/{id} (GET)
	Add order /api/Order (POST)
	
Sample POST JSON

	{
		"productOrders": [{
			"productType": {
				"Symbol": "0"
			}
		}, {
			"productType": {
				"Symbol": "|"
			}
		}, {
			"productType": {
				"Symbol": "|"
			}
		}, {
			"productType": {
				"Symbol": "."
			}
		}]
	}

Testing data used

	id 11 -> [0||.] = 133
	id 12 -> [0||..] = 133
	id 13 -> [0||::.] = 227
	id 14 -> [0||::] = 133
	id 15 -> [0||::::] = 227
	id 16 -> [0||::::.] = 321
	
