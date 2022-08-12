# MiniBankApp

Application works without database. There is only one static JSON.

Path to JSON: /Data/AccountInformation.json.

Currently application consists of two services. 
GetAccountInformation, GetAccountReportByDate. 

You can test my APIs with given link. API deployed to [Heroku](https://www.heroku.com/home) cloud platform.
[minibankapp.herokuapp.com/swagger](https://minibankapp.herokuapp.com/swagger)

/api/account/ default service which gives static data from JSON. 
 
/api/account/getReportByDate calculates income, outcome and current balance with given range of dates. 

Service requires two input parameters FromDate, ToDate with (ru-RU) culture. 

For example, you must input dates with given formats "10.01.2022".
