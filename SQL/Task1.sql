SELECT * FROM storages
WHERE StorageId IN (SELECT StorageId FROM product_storage
	WHERE VendorCode = 2)