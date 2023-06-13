package com.example.zadanieprojektowe3;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.Button;
import android.widget.EditText;

import android.view.View;

import android.util.Log;
import android.database.Cursor;
import android.widget.Toast;

import java.util.Random;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    public Button insert;
    public Button selectAll;

    public EditText name;
    public EditText surname;
    public EditText number;
    public EditText pesel;
    public EditText age;

    ZarzadzajDanymi dm;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        insert = (Button) findViewById(R.id.insert);
        selectAll = (Button) findViewById(R.id.select);
        name = (EditText) findViewById(R.id.name);
        surname = (EditText) findViewById(R.id.surname);
        number = (EditText) findViewById(R.id.number);
        pesel = (EditText) findViewById(R.id.pesel);
        age = (EditText) findViewById(R.id.age);

        dm = new ZarzadzajDanymi(this);

        insert.setOnClickListener(this);


    }

    public void showData(Cursor c)
    {
        StringBuilder data = new StringBuilder();

        int nameIndex = c.getColumnIndex(ZarzadzajDanymi.TABLE_ROW_NAME);
        int surnameIndex = c.getColumnIndex(ZarzadzajDanymi.TABLE_ROW_SURNAME);
        int numberIndex = c.getColumnIndex(ZarzadzajDanymi.TABLE_ROW_NUMBER);
        int peselIndex = c.getColumnIndex(ZarzadzajDanymi.TABLE_ROW_PESEL);
        int ageIndex = c.getColumnIndex(ZarzadzajDanymi.TABLE_ROW_AGE);

        if (c.moveToFirst())
        {
            do
            {
                String name = c.getString(nameIndex);
                String surname = c.getString(surnameIndex);
                String number = c.getString(numberIndex);
                String pesel = c.getString(peselIndex);
                String age = c.getString(ageIndex);

                data.append("Name: ").append(name)
                        .append("\nSurname: ").append(surname)
                        .append("\nNumber: ").append(number)
                        .append("\nPesel: ").append(pesel)
                        .append("\nAge: ").append(age)
                        .append("\n\n");
            } while (c.moveToNext());
        }

        Toast.makeText(this, data.toString(), Toast.LENGTH_LONG).show();
    }

    @Override
    public void onClick(View view)
    {
        switch (view.getId())
        {
            case R.id.insert:
                String enteredName = name.getText().toString().isEmpty() || hasAnyNumber(name.getText().toString()) ? generateRandomNames(5) : name.getText().toString().toUpperCase(); // Rozwiązanie z hasAnyNumber przy pomocy ChatGPT
                String enteredSurname = surname.getText().toString().isEmpty() || hasAnyNumber(surname.getText().toString()) ? generateRandomNames(10) : surname.getText().toString().toUpperCase();
                int enteredNumber;
                try
                {
                    enteredNumber = number.getText().toString().isEmpty() || !goodLength(number.getText().toString(), 9) ? generateRandomNumber() : Integer.parseInt(number.getText().toString());
                }
                catch (NumberFormatException e)
                {
                    enteredNumber = generateRandomNumber();
                }
                String enteredPesel = pesel.getText().toString().isEmpty() || !pesel.getText().toString().matches("\\d+") || !goodLength(pesel.getText().toString(), 11) ? generateRandomPesel() : pesel.getText().toString();
                int enteredAge;
                try
                {
                    enteredAge = age.getText().toString().isEmpty() || Integer.parseInt(age.getText().toString()) < 15 || Integer.parseInt(age.getText().toString()) > 85 ? generateRandomAge() : Integer.parseInt(age.getText().toString());
                }
                catch (NumberFormatException e)
                {
                    enteredAge = generateRandomAge();
                }

                dm.insert(enteredName, enteredSurname, enteredNumber, enteredPesel, enteredAge);

                String message = "Wprowadzone:\nImie: " + enteredName + "\nNazwisko: " + enteredSurname +
                        "\nNumer: " + enteredNumber + "\nPesel: " + enteredPesel + "\nWiek: " + enteredAge;
                showToast(message);
                break;

            case R.id.select:
                showData(dm.selectAll());
                break;
        }
    }

    private int generateRandomAge()
    {
        Random random = new Random();
        int min = 15;
        int max = 75;
        return random.nextInt(max - min + 1) + min;
    }

    private String generateRandomNames(int length)
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder();

        String characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < length; i++)
        {
            int index = random.nextInt(characters.length());
            char randomChar = characters.charAt(index);
            sb.append(randomChar);
        }
        return sb.toString();
    }

    private int generateRandomNumber()
    {
        Random random = new Random();
        int min = 100000000;
        int max = 999999999;
        return random.nextInt(max - min + 1) + min;
    }

    private boolean goodLength(String value, int length)
    {
        return value.length() == length;
    }

    private String generateRandomPesel()
    {
        Random random = new Random();
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < 11; i++)
        {
            int number = random.nextInt(10);
            sb.append(number);
        }

        return sb.toString();
    }

    private boolean hasAnyNumber(String text)
    {
        return text.matches(".*\\d.*");
    }

    private void showToast(String message)
    {
        Toast.makeText(this, message, Toast.LENGTH_SHORT).show();
    }
}