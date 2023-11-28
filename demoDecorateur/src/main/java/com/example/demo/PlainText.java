package com.example.demo;

// La classe va sauvegarder notre texte afin de pouvoir le décorer par la suite.
public record PlainText(String content) implements Text {
}
