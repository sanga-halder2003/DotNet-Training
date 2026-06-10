-- ========================================= EASY QUESTIONS ==========================================
-- Problem #1
-- Display the member id, member name, city and membership status
-- of members having lifetime membership (Permanent)
-- =========================================
select MEMBER_ID,MEMBER_NAME,CITY,MEMBERSHIP_STATUS
FROM LMS_MEMBERS
WHERE MEMBERSHIP_STATUS = 'Permanent'


-- =========================================
-- Problem #2
-- Display the member id and member name of members
-- who have not returned the books.
-- =========================================

SELECT M.MEMBER_ID,M.MEMBER_NAME
FROM LMS_MEMBERS M
INNER JOIN LMS_BOOK_ISSUE B
ON M.MEMBER_ID = B.MEMBER_ID
WHERE B.BOOK_ISSUE_STATUS = 'Y';


-- =========================================
-- Problem #3
-- Display the member id and member name of members
-- who have taken the book with book code 'BL000002'.
-- =========================================
SELECT M.MEMBER_ID, M.MEMBER_NAME
FROM LMS_MEMBERS M
INNER JOIN LMS_BOOK_ISSUE I
ON M.MEMBER_ID = I.MEMBER_ID
WHERE I.BOOK_CODE = 'BL000002'


-- =========================================
-- Problem #4
-- Display the book code, book title and author
-- of books whose author name begins with 'P'.
-- =========================================
SELECT BOOK_CODE,BOOK_TITLE,AUTHOR
FROM LMS_BOOK_DETAILS
WHERE AUTHOR LIKE 'P%';


-- =========================================
-- Problem #5
-- Display the total number of JAVA books available
-- with alias name NO_OF_BOOKS.
-- =========================================
SELECT COUNT(BOOK_CODE) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
WHERE CATEGORY = 'JAVA'


-- =========================================
-- Problem #6
-- Display category-wise count of books
-- with alias name NO_OF_BOOKS.
-- =========================================
SELECT CATEGORY,COUNT(BOOK_CODE) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
GROUP BY CATEGORY


-- =========================================
-- Problem #7
-- Display the number of books published by
-- 'Prentice Hall' with alias name NO_OF_BOOKS.
-- =========================================
SELECT COUNT(BOOK_CODE) AS NO_OF_BOOKS
FROM LMS_BOOK_DETAILS
WHERE PUBLICATION =  'Prentice Hall'


-- =========================================
-- Problem #8
-- Display the book code and book title
-- of books issued on 01-Apr-2012.
-- =========================================
SELECT B.BOOK_CODE, B.BOOK_TITLE
FROM LMS_BOOK_DETAILS B
INNER JOIN LMS_BOOK_ISSUE I
ON B.BOOK_CODE = I.BOOK_CODE
WHERE I.DATE_ISSUE = '01-Apr-2012'



-- =========================================
-- Problem #9
-- Display member id, member name,
-- registration date and expiry date
-- whose membership expires before April 2013.
-- =========================================
SELECT MEMBER_ID, MEMBER_NAME, DATE_REGISTER, DATE_EXPIRE
FROM LMS_MEMBERS 
WHERE DATE_EXPIRE < '01-Apr-2013'



-- =========================================
-- Problem #10
-- Display member id, member name,
-- registration date and membership status
-- for temporary members registered before March 2012.
-- =========================================
SELECT MEMBER_ID, MEMBER_NAME, DATE_REGISTER, DATE_EXPIRE, MEMBERSHIP_STATUS
FROM LMS_MEMBERS
WHERE DATE_REGISTER < '01-Mar-2012' AND MEMBERSHIP_STATUS = 'Temporary'


-- =========================================
-- Problem #11
-- Display member id and member name
-- for members belonging to CHENNAI or DELHI.
-- Display member name in title case as NAME.
-- =========================================
SELECT 
    MEMBER_ID,
    UPPER(LEFT(MEMBER_NAME, 1)) + LOWER(SUBSTRING(MEMBER_NAME, 2, LEN(MEMBER_NAME))) AS NAME
FROM LMS_MEMBERS
WHERE CITY IN ('CHENNAI', 'DELHI');


-- =========================================
-- Problem #12
-- Concatenate book title and author
-- in the format:
-- Book_Title_is_written_by_Author
-- Alias: BOOK_WRITTEN_BY
-- =========================================
SELECT 
    BOOK_TITLE + '_is_written_by_' + AUTHOR AS BOOK_WRITTEN_BY
FROM LMS_BOOK_DETAILS;


-- =========================================
-- Problem #13
-- Display the average price of JAVA books
-- with alias name AVERAGEPRICE.
-- =========================================
SELECT 
    AVG(PRICE) AS AVERAGEPRICE
FROM LMS_BOOK_DETAILS
WHERE CATEGORY = 'JAVA';


-- =========================================
-- Problem #14
-- Display supplier id, supplier name and email
-- of suppliers having Gmail accounts.
-- =========================================
SELECT 
   SUPPLIER_ID, SUPPLIER_NAME, EMAIL
   FROM LMS_SUPPLIERS_DETAILS
WHERE EMAIL LIKE '%@gmail.com';


-- =========================================
-- Problem #15
-- Display supplier id, supplier name and contact details.
-- Use COALESCE:
-- Contact -> Email -> Address
-- Alias: CONTACTDETAILS
-- =========================================
SELECT 
    SUPPLIER_ID,
    SUPPLIER_NAME,
    COALESCE(EMAIL, ADDRESS) AS CONTACTDETAILS
FROM LMS_SUPPLIERS_DETAILS;


-- =========================================
-- Problem #16
-- Display supplier id, supplier name and phone availability.
-- If phone exists display 'Yes'
-- otherwise display 'No'.
-- Alias: PHONENUMAVAILABLE
-- ==========================
SELECT 
    SUPPLIER_ID,
    SUPPLIER_NAME,
    CASE 
        WHEN CONTACT IS NOT NULL THEN 'Yes'
        ELSE 'No'
    END AS PHONENUMAVAILABLE
FROM LMS_SUPPLIERS_DETAILS;