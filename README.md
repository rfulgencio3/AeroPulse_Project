# AeroPulse_Project

## Overview

## Documentation
- docs/project_context.md
- docs/architecture_overview.md
- docs/engineering_standards.md

## Infrastructure
The local infrastructure stack uses Docker Compose and provides RabbitMQ (with management UI) and PostgreSQL.

Start:
```powershell
build/scripts/up.ps1
```
```bash
build/scripts/up.sh
```

Stop:
```powershell
build/scripts/down.ps1
```
```bash
build/scripts/down.sh
```

Default endpoints:
- RabbitMQ: amqp://localhost:5672 (user: aeropulse, pass: aeropulse)
- RabbitMQ UI: http://localhost:15672
- PostgreSQL: localhost:5432 (db: aeropulse, user: aeropulse, pass: aeropulse)

## Getting Started

## Build & Test

## Project Structure

## Notes
