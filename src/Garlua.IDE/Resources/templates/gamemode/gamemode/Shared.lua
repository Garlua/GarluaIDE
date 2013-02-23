GM.Name		= "{{name}}"
GM.Author	= "{{author}}"
GM.Email	= "{{email}}"
GM.Website  = "{{website}}"
DeriveGamemode( "sandbox" ) -- Derive from Sandbox. If you want the Q menu's and Garry's scoreboard, keep this

team.SetUp( 1, "Guest", Color( 125, 125, 125, 255 ) )
team.SetUp( 2, "Admin", Color( 255, 255, 255, 255 ) )
team.SetUp( 3, "Darkcha0s", Color( 148, 0, 211, 255 ) ) 
team.SetUp( 4, "Joining", Color( 0, 0 , 0, 255 ) )