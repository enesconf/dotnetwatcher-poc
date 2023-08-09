# Watcher

`Watcher` is a change detection and automatic build tool specially designed for platforms using dotnet. Utilizing the modern .NET 7 infrastructure, this tool instantly detects changes made in platforms and automatically initiates the necessary processes. If you add an uncompiled .NET code into the `/proj` directory, `Watcher` will automatically compile and run this code.

## Problem

In platforms used by our client, there's a requirement to create a separate .NET project for each customer. This can lead to lengthy build processes and complicated deployment steps for each change. Additionally, developers constantly building on their own machines can be time-consuming and resource-intensive.

## Solution with Watcher

`Watcher` continuously monitors the directories of the project. It detects changes in files instantly and triggers the automatic build process:

- **Directory Monitoring**: Continuously observes the project directories.
- **Instant Change Detection**: Every change in files is detected instantly.
- **Automatic Build**: Upon detecting a change, it automatically compiles the project.

These features not only speed up the process but also simplify the development workflow and optimize resource consumption.

## Docker Integration

For consistent behavior across different environments, you can utilize Docker:

### Building the Docker Image

Navigate to the directory containing your `Dockerfile` and use the following command to build a Docker image named `watcher`:

```bash
docker build -t watcher .
```

### Running the Docker Container

After building the image, you can run it using:

```bash
docker run -v /proj:/proj watcher
```

This command binds the `/proj` directory to the container, enabling the `watcher` to monitor changes in that directory.

