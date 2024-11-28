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

![{7D04D1F2-2B1A-49DC-84B6-4BA6BE58D002}](https://github.com/user-attachments/assets/82113644-8a60-4ac4-ba02-ba9c1ab8a4bb)

If it looks like this, where there's vertical empty space between the news, it's not working as intended:

![{C6BE81AC-E434-4B3D-9C65-495F064C3C69}](https://github.com/user-attachments/assets/9891f676-8e18-4056-a03b-46027899c042)
