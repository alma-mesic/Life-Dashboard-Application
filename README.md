# Life-Dashboard-Application

A C# desktop life-simulation app with gamified daily decisions and dynamic status tracking.

## Description

Life-Dashboard-Application is a gamified desktop app where users can manage their daily activities, monitor energy, focus, stress, and happiness, complete missions, earn rewards, and purchase items to boost their stats. The app includes login and sign-up functionality, dynamic avatar display, and interactive status bars.

## Features

- **Login & Sign Up:** User data is stored in `korisnik.txt`. Users can create an account with a username, password, birthday, gender, and avatar.  
- **Home (Form3):** Displays the user’s avatar in a PictureBox linked to an ImageList containing 12 avatar images (4 moods × 3 avatars). Six buttons manipulate energy, focus, stress, and happiness; four additional buttons demonstrate status changes.  
- **Menu Strip:** Navigation includes Home, Missions, Shop, and Settings tabs.  
- **Missions:** Users can add tasks with a name and priority (High, Medium, Low) using a TextBox and RadioButtons. Tasks can be deleted, sorted alphabetically or by priority, and marked as completed, moving them to a "Completed Tasks" list. Completing tasks awards **Score** and **Coins**.  
- **Shop:** Spend Coins to purchase potions that refill Energy, Focus, or Happiness. The status bars on Home update dynamically according to purchases.  
- **Settings:** Profile form allows users to change their password by entering username, old password, and new password. Logout returns to the login form, and the Exit option closes the application.

## Icon Attribution

- **Avatars in Home (Form3):** Created by [Aslaiart](https://www.flaticon.com/authors/aslaiart).  
- **Potion icons in Shop:** Created by [Vectors Market15](https://www.flaticon.com/authors/vectorsmarket15).  

All icons are used under the Flaticon free license, with proper attribution provided.
