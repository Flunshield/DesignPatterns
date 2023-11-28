// J'ai créé un décorateur de modification de chaîne de caractères pour formater un texte spécifique en gras.
// Pour cela, plusieurs fichiers ont été créés (voir le code source) pour permettre l'utilisation du décorateur
// "BoldDecorator".

package com.example.demo;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HelloController {

    // Création d'un composant de base
    Text text = new PlainText("Hello, Decorator Pattern!");

    // Ajout du décorateur
    Text boldText = new BoldDecorator(text);

    @GetMapping("/hello")
    public String sayHello() {
        return ("Texte en gras : " + boldText.content());
    }
}
