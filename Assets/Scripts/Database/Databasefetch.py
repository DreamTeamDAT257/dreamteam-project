import openpyxl

# Open the Excel file
workbook = openpyxl.load_workbook('Data.xlsx')

# Select the active worksheet
worksheet = workbook.active

# Open the output file for writing
output_file = open('output.txt', 'w')

# Loop through each row in the worksheet
for row in worksheet.iter_rows():
    # Loop through each cell in the row
    for cell in row:
        # Write the cell value to the output file, separated by tabs
        output_file.write(str(cell.value) + '\t')
    # End the row with a newline character
    output_file.write('\n')

# Close the output file
output_file.close()

# Close the Excel file
workbook.close()