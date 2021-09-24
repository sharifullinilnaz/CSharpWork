SELECT * FROM products
	WHERE VendorCode IN (SELECT VendorCode FROM product_storage
	JOIN storages ON product_storage.StorageId = storages.StorageId
	WHERE City = 'Kazan')