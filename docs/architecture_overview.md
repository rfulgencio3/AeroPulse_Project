# Architecture Overview

## Objective
This document contrasts the current OLD approach with the FAIR target state so the team can align around migration priorities and architectural decisions.

## OLD Approach (Legacy/Fragmented)
- Data is siloed by operator and system with inconsistent schemas.
- Integrations are point-to-point and fragile, requiring manual intervention.
- Business logic is duplicated across services and scripts.
- Reporting relies on ad-hoc extracts and manual reconciliation.
- Observability is limited; incidents are detected late and triage is slow.
- Auditing is incomplete, making compliance verification expensive.

## FAIR Approach (Target State)
- Findable: standardized identifiers, searchable metadata, and cataloged datasets.
- Accessible: controlled, audited access via APIs and governed data products.
- Interoperable: canonical domain model with strict schema versioning.
- Reusable: clear data contracts, provenance, and quality metrics.

## Key Differences
- Integration: from point-to-point to event-driven and API-first.
- Data Model: from per-source schemas to a canonical model with extension points.
- Governance: from implicit rules to explicit policies and data contracts.
- Operations: from reactive to observable, with measurable SLAs.

## Migration Focus
- Establish canonical identifiers and a shared domain vocabulary.
- Implement data contracts and schema governance early.
- Replace ad-hoc reporting with governed data products.
- Improve observability to measure reliability and data quality.
