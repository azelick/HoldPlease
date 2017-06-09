System and Acceptance Test Documentation

We haven't implemented them, but if we would, a few of the System and Acceptance tests 
that we would write are below. 

1.
Verify that when you creat a user, that they are populated into the DB correctly
and that they can be accessed with no corruption.

2. 
Verify that when a user creates their service request, that it shows up in the 
list of available service requests.

3. 
Verify that a user can't change their cost per hour after a service is 
accepted.

4. 
Verify that if a user selects back from the accept service page before accepting, 
that the service remains un-accepted.


In general, we want to make sure that user and system data is preserved. We
want to make sure that a user can't edit or delete any of the information of 
another user.

Additionally we want to make sure that the operations are fast and there isn't
a long delay when visiting various indices of the website.