package com.example.zadanieprojektowe3;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;

import android.database.sqlite.SQLiteOpenHelper;

import android.util.Log;



public class ZarzadzajDanymi
{
    private SQLiteDatabase db;

    public static final String TABLE_ROW_ID = " _id";
    public static final String TABLE_ROW_NAME = "name";
    public static final String TABLE_ROW_SURNAME = "surname";
    public static final String TABLE_ROW_NUMBER = "phone";
    public static final String TABLE_ROW_PESEL = "pesel";
    public static final String TABLE_ROW_AGE = "age";

    private static final String DB_NAME = "address_book_db";
    private static final int DB_VERSION = 1;
    private static final String TABLE_FULL_TABLE = "full_table";

    private class CustomSQLiteOpenHelper extends SQLiteOpenHelper
    {

        public CustomSQLiteOpenHelper(Context context)
        {
            super(context, DB_NAME, null, DB_VERSION);
        }

        @Override
        public void onCreate(SQLiteDatabase sqLiteDatabase)
        {
            String newTableQueryString = "CREATE TABLE " + TABLE_FULL_TABLE + " ("
                    + TABLE_ROW_ID + " INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "
                    + TABLE_ROW_NAME + " TEXT, "
                    + TABLE_ROW_SURNAME + " TEXT, "
                    + TABLE_ROW_NUMBER + " INTEGER, "
                    + TABLE_ROW_PESEL + " TEXT, "
                    + TABLE_ROW_AGE + " INTEGER)";
            sqLiteDatabase.execSQL(newTableQueryString);

        }
        @Override
        public void onUpgrade(SQLiteDatabase sqLiteDatabase, int i, int i1)
        {

        }
    }
    public ZarzadzajDanymi (Context context) {
        CustomSQLiteOpenHelper helper = new CustomSQLiteOpenHelper(context);
        db = helper.getWritableDatabase();
    }
    public void insert (String name, String surname, int number, String pesel, int age)
    {
        String query = "INSERT INTO " + TABLE_FULL_TABLE + " ("
                + TABLE_ROW_NAME + ", "
                + TABLE_ROW_SURNAME + ", "
                + TABLE_ROW_NUMBER + ", "
                + TABLE_ROW_PESEL + ", "
                + TABLE_ROW_AGE + ") VALUES ("
                + "'" + name + "', "
                + "'" + surname + "', "
                + number + ", "
                + pesel + ", "
                + age + ")";
        Log.i("insert() = ", query);
        db.execSQL(query);
    }

    public Cursor selectAll()
    {
        Cursor c = db.rawQuery( "SELECT * from " + TABLE_FULL_TABLE, null);
        return c;
    }
}
