package com.example.zadanieprojektowe2;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.drawable.DrawableCompat;

import android.media.MediaPlayer;
import android.os.Bundle;
import android.content.Context;
import android.widget.Button;
import android.view.View;
import android.graphics.Color;
import android.widget.TextView;


import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;

public class MainActivity extends AppCompatActivity {

    public static final int sound_C = R.raw.c6;
    public static final int sound_D = R.raw.d6;
    public static final int sound_E = R.raw.e6;
    public static final int sound_F = R.raw.f6;
    public static final int sound_G = R.raw.g6;
    public static final int sound_A = R.raw.a6;
    public static final int sound_B = R.raw.b6;

    Button soundC;
    Button soundD;
    Button soundE;
    Button soundF;
    Button soundG;
    Button soundA;
    Button soundB;
    Button delete;
    Button play;

    int greenColor = Color.GREEN;
    int redColor = Color.RED;
    StringBuilder soundCombination;

    TextView tvSoundNames;


    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        soundC = (Button)findViewById(R.id.b1);
        soundD = (Button)findViewById(R.id.b2);
        soundE = (Button)findViewById(R.id.b3);
        soundF = (Button)findViewById(R.id.b4);
        soundG = (Button)findViewById(R.id.b5);
        soundA = (Button)findViewById(R.id.b6);
        soundB = (Button)findViewById(R.id.b7);
        delete = (Button)findViewById(R.id.delete);
        play = (Button)findViewById(R.id.play);

        soundCombination = new StringBuilder();

        tvSoundNames = findViewById(R.id.tvSoundNames);

    }

    public void playSound(Context context, int soundID)
    {
        MediaPlayer mp = MediaPlayer.create(context, soundID);
        mp.start();
        addToCombination(soundID);
    }

    public void playSoundView(View v)
    {

        int sound = 0;
        setAllColors();

        if(soundC.getId() == v.getId())
        {
            sound = sound_C;
            setButtonBackgroundTint(soundC, greenColor);
        }
        else if(soundD.getId() == v.getId())
        {
            sound = sound_D;
            setButtonBackgroundTint(soundD, greenColor);
        }
        else if(soundE.getId() == v.getId())
        {
            sound = sound_E;
            setButtonBackgroundTint(soundE, greenColor);

        }
        else if(soundF.getId() == v.getId())
        {
            sound = sound_F;
            setButtonBackgroundTint(soundF, greenColor);

        }
        else if(soundG.getId() == v.getId())
        {
            sound = sound_G;
            setButtonBackgroundTint(soundG, greenColor);

        }
        else if(soundA.getId() == v.getId())
        {
            sound = sound_A;
            setButtonBackgroundTint(soundA, greenColor);

        }
        else if(soundB.getId() == v.getId())
        {
            sound = sound_B;
            setButtonBackgroundTint(soundB, greenColor);
        }
        playSound(this,sound);
    }

    public void setButtonBackgroundTint(Button button, int color)
    {
        DrawableCompat.setTint(button.getBackground(), color);
    }

    public void delete(View v)
    {
        setAllColors();
        soundCombination.setLength(0);
        tvSoundNames.setText(soundCombination);
    }

    public String getSoundName(int soundID)
    {
        switch (soundID)
        {
            case sound_C:
                return "C";
            case sound_D:
                return "D";
            case sound_E:
                return "E";
            case sound_F:
                return "F";
            case sound_G:
                return "G";
            case sound_A:
                return "A";
            case sound_B:
                return "H";
            default:
                return "";
        }
    }
    public void addToCombination(int soundID)
    {
        String soundName = getSoundName(soundID);
        soundCombination.append(soundName).append(" ");
        tvSoundNames.setText(soundCombination.toString());
    }

    public void write(View v)
    {
        try
        {
            setAllColors();
            FileOutputStream file_out = openFileOutput("dataFile.txt", MODE_PRIVATE);
            OutputStreamWriter out_writer = new OutputStreamWriter((file_out));
            out_writer.write(soundCombination.toString());
            out_writer.close();

        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void read(View v)
    {
        try
        {
            setAllColors();
            FileInputStream file_in = openFileInput("dataFile.txt");
            InputStreamReader input_read = new InputStreamReader((file_in));
            char[] inputBuffer = new char[100];
            String s = "";
            int charRead;
            while((charRead = input_read.read(inputBuffer)) > 0)
            {
                String readString = String.copyValueOf(inputBuffer, 0 , charRead);
                soundCombination.setLength(0);
                soundCombination.append(readString);
            }
            input_read.close();
            tvSoundNames.setText(soundCombination);

        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }

    public void playActiveMelody(View v)
    {
        setAllColors();
        String melody = soundCombination.toString();
        delete(v);

        for (int i = 0; i < melody.length(); i++)
        {
            char soundChar = melody.charAt(i);
            int soundID = getSoundID(soundChar);

            if (soundID != 0)
            {
                playSound(this, soundID);
                try
                {
                    Thread.sleep(200); //
                }
                catch (Exception e) {
                    e.printStackTrace();
                }
            }

        }
    }

    public int getSoundID(char soundChar)
    {
        switch (soundChar)
        {
            case 'C':
                return sound_C;
            case 'D':
                return sound_D;
            case 'E':
                return sound_E;
            case 'F':
                return sound_F;
            case 'G':
                return sound_G;
            case 'A':
                return sound_A;
            case 'H':
                return sound_B;
            default:
                return 0;
        }
    }

    public void setAllColors()
    {
        setButtonBackgroundTint(soundC, redColor);
        setButtonBackgroundTint(soundD, redColor);
        setButtonBackgroundTint(soundE, redColor);
        setButtonBackgroundTint(soundF, redColor);
        setButtonBackgroundTint(soundG, redColor);
        setButtonBackgroundTint(soundA, redColor);
        setButtonBackgroundTint(soundB, redColor);
    }


}

