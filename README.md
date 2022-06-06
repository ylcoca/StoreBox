# StoreBox
Description
Business flow

	A customer can order 1 or multiple items.
	For example, an order could consist of a photo book and 2 canvases.
	After the order is produced, it is delivered to one out of thousands of pickup points across the country.
	The package is put in a bin on a shelf at the pickup point. The bin has to be sufficiently wide for the package.
	Since bins are reserved upfront, we need to calculate the minimum bin width required for the order at the moment of order creation.

Objective

	Create a .NET Web API that accepts an order, stores it, and responds with the minimum bin width.
	We also should be able to get back all the information that is known about the order by its ID.
	Cover code with tests where you find it important.

	Order information submitted by customers:

		OrderID
		ProductType and Quantity. // Product type can be 1 of type photoBook, calendar, canvas, cards, mug

	Order information retrievable from the Web API by OrderID:

		ProductType with quantity
		RequiredBinWidth in millimeters (mm)
		
Simplified width calculation rules

	Items are put in the package next to each other (for simplicity of the test assignment).
	For example, 1 photo book (0), 2 calendars (|) and 1 mug (.) should look like this in the package: [0||.]

	But a mug has 1 detail: it can be stacked onto each other (up to 4 in a stack). So, an order with 1 photo book, 2 calendars, and 2 mugs should be positioned like this: [0||:]

	So the width of the 2 packages above is exactly the same. It would be still the same even if we add 2 more mugs (4 in total) but would increase if we add a 5th mug.

	Package width occupied by 1 product unit per type:

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
			"Symbol": "0",
			"ProductTypeName": "photoBook"
		}
	}, {
		"productType": {
			"Symbol": "|",
			"ProductTypeName": "calendar"
		}
	}, {
		"productType": {
			"Symbol": "|",
			"ProductTypeName": "calendar"
		}
	}, {
		"productType": {
			"Symbol": ".",
			"ProductTypeName": "mug"
		}
	}]
}

Returns 133 that is the minimum bin width

Testing data used

	id 10 -> [/0] = 35
	id 11 -> [0||.] = 133
	id 12 -> [0||..] = 133
	id 13 -> [0||::.] = 227
	id 14 -> [0||::] = 133
	id 15 -> [0||::::] = 227
	id 16 -> [0||::::.] = 321
	
