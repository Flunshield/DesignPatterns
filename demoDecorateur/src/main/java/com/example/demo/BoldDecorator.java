package com.example.demo;

// La classe va servire a modifier le texte
public class BoldDecorator extends TextDecorator {
    public BoldDecorator(Text wrappedText) {
        super(wrappedText);
    }

    @Override
    public String content() {
        return "<b>" + super.content() + "</b>";
    }
}
