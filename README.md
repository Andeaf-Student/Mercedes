# Reprezentanță Mercedes

## Funcționalități principale

### Autentificare utilizatori
Accesul în aplicație este restricționat și se realizează pe baza unor date de autentificare (**username** și **parolă**) furnizate fiecărui angajat al reprezentanței.

### Vizualizarea stocului de mașini
Aplicația afișează o listă completă cu toate autoturismele disponibile în reprezentanță, incluzând informații precum:
- modelul
- anul de fabricație
- motorizarea
- prețul
- disponibilitatea

### Gestionarea disponibilității
În momentul în care un client este interesat de achiziția unui autoturism, angajatul poate verifica rapid dacă acesta este disponibil pentru vânzare.

### Procesul de cumpărare
Vânzarea unei mașini se realizează pe baza datelor clientului:

- **Nume**
- **Prenume**
- **CNP**

Toate aceste informații, împreună cu detaliile mașinii achiziționate, sunt salvate într-o bază de date.

### Actualizarea automată a stocului
După finalizarea unei vânzări, autoturismul este marcat automat ca **indisponibil**, nemaiputând fi achiziționat de alți clienți.

---

## Detalii tehnice ale autoturismelor

Pentru fiecare autoturism din reprezentanța **Mercedes-Benz**, aplicația stochează și afișează informații tehnice detaliate, necesare atât angajaților, cât și clienților interesați de achiziție.

Datele asociate fiecărei mașini includ, dar nu se limitează la:

- **Modelul autoturismului**
- **Anul de fabricație**
- **Tipul de motorizare** (benzină, diesel, hibrid, electric)
- **Capacitatea cilindrică**
- **Numărul de cai putere (CP)**
- **Numărul de kilometri parcurși**
- **Tipul transmisiei** (manuală / automată)
- **Prețul de vânzare**
- **Starea de disponibilitate** (disponibil / vândut)
