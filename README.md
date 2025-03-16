# Freelancer Directory Web App  

##  Project Description  
This is a simple web application for managing freelancers.  
Users can add, update, delete, archive, and unarchive freelancers using a RESTful API throught the simple UI built in ASP.NET Core.  

##  Features  
- CRUD operations for freelancers  
- Search by ID / Username / Email
- Archive and Unarchive freelancers  
- Fully responsive frontend  

##  Technologies Used  
- Backend: ASP.NET Core Web API  
- Database: MS SQL Server  
- Frontend: HTML, JavaScript, Fetch API, AJAX
- Azure App Service (for API Hosting & UI)
- Azure SQL Database (for database storage)

##  API Endpoint
- POST /api/freelancers → Create a freelancer.
- GET /api/freelancers/{id} → Get freelancer by ID.
- GET /api/freelancers?search=kelvin → Wildcard search by username or email.
- PUT /api/freelancers/{id} → Update a freelancer.
- DELETE /api/freelancers/{id} → Delete a freelancer.
- PUT /api/freelancers/{id}/archive → Archive a freelancer.
- PUT /api/freelancers/{id}/unarchive → Unarchive a freelancer.
