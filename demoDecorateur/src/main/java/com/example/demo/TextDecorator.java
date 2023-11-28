package com.example.demo;

/*

Cette classe abstraite, TextDecorator, implémente l'interface Text et encapsule un objet de type Text,
agissant comme une base pour les décorateurs qui étendent cette classe et ajoutent des fonctionnalités
supplémentaires au contenu du texte d'origine.
 */
public abstract class TextDecorator implements Text {
    private final Text wrappedText;

    public TextDecorator(Text wrappedText) {
        this.wrappedText = wrappedText;
    }

    @Override
    public String content() {
        return wrappedText.content();
    }
}
