SELECT * FROM storages
WHERE StorageId IN (SELECT StorageId FROM product_storage 
	WHERE Amount = (SELECT MAX(Amount)
	FROM product_storage
	WHERE VendorCode = 7) AND VendorCode = 7);