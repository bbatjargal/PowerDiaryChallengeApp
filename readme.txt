Power Diary coding assignment for SW Engineer interview


The Challenge: You are implementing a chat room interface in which the user can view chat history at varying levels of time-based aggregation. For example, they can choose to see every chat event as it occurred, or stats about chat events for a given day.



You do NOT have to implement the actual chat functionality - we are only interested in how the data is sorted, aggregated and rendered.



There are a few event types:



enter-the-room
leave-the-room
comment
high-five-another-user


Write an application that displays these events in descending chronological order, for example:



Granularity: minute by minute


	   5pm: Bob enters the room
	5:05pm: Kate enters the room
	5:15pm: Bob comments: "Hey, Kate - high five?"
	5:17pm: Kate high-fives Bob
	5:18pm: Bob leaves
	5:20pm: Kate comments: "Oh, typical"
	5:21pm: Kate leaves


The user can select an "aggregation level" which allows viewing the chat events aggregated together so that a long span of time can be viewed quickly, for example:



Granularity: Hourly


	5pm: 	1 person entered
			2 left	
			1 person high-fived 1 other person
			2 comments
	6pm:	3 people entered
			1 person high-fived 3 other people
			15 comments


You may choose your implementation to be a web page, a terminal application, a GUI, a mobile app, a set of Postgres stored procedures, etc.



You may choose to implement persistence via a database, but that isn't necessary. You can just create the data in memory when the application is run or load it from a file.



We are far more interested in seeing well-crafted, well-factored code than a fancy user interface.



We are not expecting perfection, as we have yet to achieve it ourselves!



Tests are HIGHLY encouraged.