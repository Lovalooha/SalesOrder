use SalesOperation

INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('John Doe')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Erwin')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Kevin')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Steven')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Christrine')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Jessica')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Melinda')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Joseph')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Wahyu')
INSERT INTO COM_CUSTOMER (CUSTOMER_NAME) VALUES ('Gilbert')

select * from com_customer

INSERT INTO SO_ORDER (ORDER_NO, ORDER_DATE, COM_CUSTOMER_ID, ADDRESS) VALUES ('50_001', GETUTCDATE(), 9, 'JL. factory no 23')
INSERT INTO SO_ORDER (ORDER_NO, ORDER_DATE, COM_CUSTOMER_ID, ADDRESS) VALUES ('50_002', GETUTCDATE(), 2, 'JL. kampung durian runtuh')
INSERT INTO SO_ORDER (ORDER_NO, ORDER_DATE, COM_CUSTOMER_ID, ADDRESS) VALUES ('50_003', GETUTCDATE(), 3, 'JL. sinar jaya mas')
INSERT INTO SO_ORDER (ORDER_NO, ORDER_DATE, COM_CUSTOMER_ID, ADDRESS) VALUES ('50_004', GETUTCDATE(), 4, 'JL. mangga manis')
INSERT INTO SO_ORDER (ORDER_NO, ORDER_DATE, COM_CUSTOMER_ID, ADDRESS) VALUES ('50_005', GETUTCDATE(), 5, 'JL. langit guntur')

select * from SO_ORDER

INSERT INTO SO_ITEM (SO_ORDER_ID, ITEM_NAME, QUANTITY, PRICE) VALUES ('1','KULKAS', 1, 2500000)
INSERT INTO SO_ITEM (SO_ORDER_ID, ITEM_NAME, QUANTITY, PRICE) VALUES ('2','TV', 1, 7900000)
INSERT INTO SO_ITEM (SO_ORDER_ID, ITEM_NAME, QUANTITY, PRICE) VALUES ('3','AC', 1, 1000000)
INSERT INTO SO_ITEM (SO_ORDER_ID, ITEM_NAME, QUANTITY, PRICE) VALUES ('4','KOMPUTER', 1, 5000000)
INSERT INTO SO_ITEM (SO_ORDER_ID, ITEM_NAME, QUANTITY, PRICE) VALUES ('5','LEMARI', 1, 3500000)

SELECT * FROM SO_ITEM

--SP GET ALL CUSTOMER DATA
GO
CREATE  PROCEDURE [dbo].[GET_LIST_CUSTOMER]     
AS    
BEGIN    
	SELECT
		  A.COM_CUSTOMER_ID
		, A.CUSTOMER_NAME
	FROM dbo.COM_CUSTOMER A 
END 
