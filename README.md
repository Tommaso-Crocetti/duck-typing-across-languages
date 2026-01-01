# Duck Typing Across Programming Languages

This repository presents a comparative study of **duck typing** across
multiple programming languages through small, focused code examples.

Duck typing is commonly summarized by the principle:

> “If it walks like a duck and quacks like a duck, it is a duck.”

Rather than relying on declared types or inheritance hierarchies,
duck typing determines compatibility based on **runtime behavior**.

---

## Purpose of the Repository

The goal of this project is to:

- Demonstrate how duck typing works in languages where it is **native**
- Show how duck typing can be **emulated** in nominally typed languages
- Compare **runtime flexibility** versus **compile-time safety**
- Highlight the trade-offs between different language designs

This repository is intended for **educational and academic purposes**.

---

## Languages and Approaches

The repository includes examples in multiple languages, each illustrating
a different relationship with duck typing:

- **Python**
  - Native duck typing
  - Runtime behavior determines compatibility
  - Minimal boilerplate, runtime errors on misuse

- **JavaScript**
  - Native duck typing via dynamic objects and prototype-based dispatch
  - High flexibility, limited static guarantees

- **Java & C#**
  - Duck typing emulated using `dynamic`, reflection, interfaces, and delegates
  - Strong compile-time guarantees, limited runtime flexibility

Each language is contained in its own folder with runnable examples and
a dedicated `README.md`.

---

## Repository Structure

```text
duck-typing-across-languages/
│
├── Python/
├── JavaScript/
├── Java/
├── C#/
├── README.md
└── LICENSE
