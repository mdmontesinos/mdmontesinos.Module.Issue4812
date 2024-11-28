Minimal Oqtane module to reproduce the issue described at https://github.com/oqtane/oqtane.framework/issues/4812.

Steps:
- Create a new empty page in your Oqtane site
- Add a new module instance for Issue4812
- Logout (just in case)
- Open a new incognito browser
- Open the Oqtane home page
- Navigate to the page that contains the module

The error described should appear:
![image](https://github.com/user-attachments/assets/3998cffe-ca67-415b-80b4-50bebc2a51e4)

Or this error related to the masonry grid not loading:

![{FC0F7F60-0709-45D2-AF37-AD1D4C70A66F}](https://github.com/user-attachments/assets/4bb97d3a-b4a3-4db9-9a3e-c0dd4e21176d)

To verify that it's working properly, the images grid should look like this:

![{C795F6C2-AF86-41E0-80DF-299A54ED5841}](https://github.com/user-attachments/assets/ae7958b4-ea12-4eb7-8d34-dd2f682e5957)

If it looks like this, where there's vertical empty space between the news, it's not working as intended:

![{584F4E86-494F-4412-B0D0-04127AD70A7B}](https://github.com/user-attachments/assets/dd465b27-b44d-462d-99d4-c6a35bbc7e15)
