## TEST for SEH America

Create a solution that accepts user input and generates a power point slide with;

- Title area
- [x] See first text box
- Text area
- [x] See second text area

Image suggestion area that utilizes words in the title, and bold words in the text area to bring suggested images in, with ability to select multiple images to include in the slide

- [x] Search uses the title and bolded words in the text area
- [x] Ability to select multiple images

Have them make windows form to provide the solution.

- [x] WinForms .NET Core 3.1 delivered with Net Standard Core library for a set of the business logic

Question about person not having PowerPoint: “If he can output to any file that accepts images and text, that all that is really required.”

- [x] Decided to use HTML for simplicity, timing sake and everyone has a browser
  - Possible to convert HTML to Word and PDF
  - Could have used Microsoft Interop, but tend to stay away from it and I do not have office products
  - Could have used OpenXML, but I have used it in the past and remember it takes a lot of perfecting or a ton of reflected code

- [x] Pictures come from Google and when the API usage for the day runs out, a set of test image links have been embedded to display