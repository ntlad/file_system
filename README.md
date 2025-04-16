# file_system
An application for interacting with and managing the file system.

# Formulation

Develop an application for interacting with and managing a file system.
# Functional requirements

- Navigating the file system tree (relative and absolute paths)
- Viewing directory contents in the console
- Viewing file contents in the console
- Moving files
- Copying files
- Deleting files
- Renaming files
- Console mechanism for interacting with the application
- Implementation of operations for the local file system
# Non-functional requirements

- The system must support interaction via console commands that have flags.
- The system's operation logic must not be tied to console command processing.
- The system must support the ability to expand console command parameters.
- Command processing must not be tied to the console.
- The system must not be tied to the local file system.
- The directory contents output must be parameterized by the selection depth (the default value is 1)
- The system directory output must be in the form of a tree.
- The parameters of the output tree (symbols denoting a file, folder, symbols used for indentation must be programmatically parameterized).
- The directory contents output logic must not be tied to the console.
- The file contents output logic must not be tied to the console.
- The system must adequately handle cases of name collisions.
- The system must be able to switch between file systems (for example, changing drive C to drive D).
- After outputting the result to the console interface, the program should wait for the next command to be entered.
- No third-party libraries can be used to implement the system

# Command semantics

- connect [Address] [-m Mode] \
  Address - absolute path in the connected file system \
  Mode - file system mode (only local FS must be implemented, value `local`)
- disconnect \
  Disconnects from the file system
- tree goto [**Path**] \
  **Path** - relative or absolute path to the directory in the file system
- tree list {-d **Depth**} \
  **Depth** - the parameter that determines the depth of the selection, must be declared with the `-d` flag
- file show [**Path**] {-m **Mode**} \
  **Path** - relative or absolute path to the file \
  **Mode** - file output mode (only console must be implemented, value `console`)
- file move [**SourcePath**] [**DestinationPath**] \
  **SourcePath** - relative or absolute path to the file being moved \
  **DestinationPath** - relative or absolute path to the directory where the file should be moved
- file copy [**SourcePath**] [**DestinationPath**] \
  **SourcePath** - relative or absolute path to the file being copied \
  **DestinationPath** - relative or absolute path to the directory where the file should be copied
- file delete [**Path**] \
  **Path** - relative or absolute path to the file being deleted
- file rename [**Path**] [**Name**] \
  **Path** - relative or absolute path to the file being changed \
  **Name** - new file name


# Test cases

- Test the command parser: processing console commands with arguments should create a command of the correct type with the correct arguments
---