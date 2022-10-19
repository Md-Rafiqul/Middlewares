# Middlewares
---

Middlewares to optimize application pipeline. Objective of this middleware is to -
- Intercept http request to extract api defined header values such as CorrelationId, Content-Type etc.
- Add custom values with response 
- In case of api returning ProblemDetails instead of throwing error [See why not to throw error](https://www.youtube.com/watch?v=a1ye9eGTB98&t=649s)
