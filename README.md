# Enigma-Machine
 Create an Enigma Machine
This Programm is a challenge to make an enigma machine whith my friend.
At beginning this code dosn't worked well. Our machines was encrypted and decrypted messages absolutly in custom, unpredited way.
Now this machine worked well, but have little mess in code because of missunderstanding the rotor principle.
As result - we got some strange constructions with variables like "rotorPosition" and "notchPosition". 
The problem is thar a rotor rotates in negative direction (A<B<C<D<E etc.), but shows on rotor positive direction(A>B>C>D>E etc).
Also was problem with conection between rotors: how to translate a properly signal? In this case i was needed
to add offsets in rotors.
And last - my Rotor class was so good defined, (or "good") that i used it for clems and reflector also.
