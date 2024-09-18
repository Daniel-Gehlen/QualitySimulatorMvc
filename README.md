# Quality Simulator MVC Application

## Overview

The Quality Simulator is an ASP.NET MVC application designed to manage electronic components and quality standards. This application provides a simple user interface for adding, removing, and viewing electronic components and their associated quality standards. 

## Technical Aspects

- **Framework**: Built on ASP.NET Core MVC, leveraging the Model-View-Controller architecture for clean separation of concerns.
- **Data Storage**: Uses a JSON file (`data.json`) for persistent storage of electronic components and quality standards, allowing easy data management without the need for a database.
- **Frontend**: The user interface is created using HTML and Razor syntax, providing a responsive and user-friendly experience.
- **Routing**: Utilizes ASP.NET routing to manage navigation between different functionalities within the application.
- **Dependency Management**: Managed through the .NET CLI and NuGet packages, ensuring all dependencies are up-to-date and properly referenced.

## Functional Aspects

- **View Components**: Users can view a list of current electronic components and quality standards.
- **Add Components**: Users can add new electronic components and quality standards through dedicated forms.
- **Remove Components**: Users can remove existing components and standards from their respective lists.
- **Dynamic Data Handling**: The application loads data from the `data.json` file at startup and saves changes back to this file, ensuring that user actions persist across sessions.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or later)
- A code editor (e.g., [Visual Studio Code](https://code.visualstudio.com/))

### Cloning the Repository

1. Open a terminal or command prompt.
2. Navigate to the directory where you want to clone the repository.
3. Run the following command to clone the repository:

   ```bash
   git clone https://github.com/Daniel-Gehlen/QualitySimulatorMvc.git
   ```

### Running the Application

1. Navigate into the project directory:

   ```bash
   cd QualitySimulatorMvc
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

4. Open your web browser and navigate to `http://localhost:5000` (or `https://localhost:5001` if using HTTPS) to access the application.

## Contributing

If you would like to contribute to the project, please open an issue or submit a pull request. Contributions are welcome!

## License

This project is licensed under the MIT License. See the LICENSE file for more details.

### Instructions
- Replace `https://github.com/your-username/QualitySimulatorMvc.git` with the actual URL of your repository.
- Feel free to modify the content to better fit your project's specific features or requirements!
