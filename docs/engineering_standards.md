# Engineering Standards

## Coding
- Use clear, intention-revealing names for classes, methods, and modules.
- Prefer small, cohesive components with explicit responsibilities.
- Avoid hidden side effects; make dependencies explicit via interfaces.
- Treat nullability as a contract; avoid implicit null assumptions.
- Keep public APIs stable; version changes when breaking behavior.

## Database
- Use a canonical schema with explicit ownership per bounded context.
- Apply migrations for every schema change; no manual edits in production.
- Enforce constraints for data integrity (FKs, unique keys, and check constraints).
- Use UTC for all timestamps and store time zone separately when needed.

## Messaging
- Use explicit message contracts with versioning and compatibility notes.
- Include correlation and causation identifiers in every message.
- Define idempotency strategy for consumers to handle retries safely.
- Prefer durable queues/topics for critical events; document retention policies.

## Logging
- Log with structured, machine-readable fields (no free-form only).
- Include correlation IDs, user/tenant IDs, and operation names.
- Define log levels consistently; errors must include actionable context.
- Avoid logging PII or secrets; apply redaction at the source.

## Migrations
- Migrations must be deterministic, reversible where feasible, and tracked in source control.
- Validate migrations in CI using a clean database instance.
- Rollback plans are required for production changes with data impact.

## Deduplication
- Define canonical identity rules per entity and document them.
- Use deterministic keys or hashes for dedup decisions.
- Record dedup decisions and retain original records for auditability.

## Indexes
- Index based on observed access patterns and SLAs, not guesses.
- Use composite indexes for common filter+sort patterns.
- Review index usage regularly; remove unused or overlapping indexes.
- Avoid over-indexing write-heavy tables.
