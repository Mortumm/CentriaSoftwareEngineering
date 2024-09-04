import PyPDF2
import tkinter as tk
from tkinter import filedialog, messagebox


# Function to combine PDF files
def combine_pdfs(input_pdfs, output_pdf):
    pdf_merger = PyPDF2.PdfFileMerger()

    for pdf_file in input_pdfs:
        pdf_merger.append(pdf_file)

    pdf_merger.write(output_pdf)
    pdf_merger.close()


# Function to reorder pages in a PDF
def reorder_pages(input_pdf, output_pdf, page_order):
    pdf_reader = PyPDF2.PdfFileReader(input_pdf)
    pdf_writer = PyPDF2.PdfFileWriter()

    for page_number in page_order:
        page = pdf_reader.getPage(page_number)
        pdf_writer.addPage(page)

    with open(output_pdf, "wb") as output_file:
        pdf_writer.write(output_file)


# Function to handle the "Merge" button click event
def merge_button_click():
    input_pdfs = selected_files
    output_pdf = filedialog.asksaveasfilename(
        defaultextension=".pdf", filetypes=[("PDF files", "*.pdf")]
    )

    if not output_pdf:
        return  # User canceled the save dialog

    try:
        combine_pdfs(input_pdfs, output_pdf)
        messagebox.showinfo("Success", "PDF files merged successfully!")
    except Exception as e:
        messagebox.showerror("Error", f"An error occurred: {str(e)}")


# Function to handle the "Reorder" button click event
def reorder_button_click():
    input_pdf = filedialog.askopenfilename(filetypes=[("PDF files", "*.pdf")])

    if not input_pdf:
        return  # User canceled the open dialog

    page_order_str = page_order_entry.get()
    try:
        page_order = [int(x) for x in page_order_str.split(",")]
        output_pdf = filedialog.asksaveasfilename(
            defaultextension=".pdf", filetypes=[("PDF files", "*.pdf")]
        )

        if not output_pdf:
            return  # User canceled the save dialog

        reorder_pages(input_pdf, output_pdf, page_order)
        messagebox.showinfo("Success", "PDF pages reordered successfully!")
    except Exception as e:
        messagebox.showerror("Error", f"An error occurred: {str(e)}")


# Function to handle the "Select Files" button click event
def select_files_button_click():
    global selected_files
    selected_files = filedialog.askopenfilenames(filetypes=[("PDF files", "*.pdf")])
    selected_files_label.config(text=f"Selected Files: {', '.join(selected_files)}")


# Create the main window
root = tk.Tk()
root.title("PDF Manipulation Tool")

# Create and configure the "Select Files" button
select_files_button = tk.Button(
    root, text="Select Files", command=select_files_button_click
)
select_files_button.pack()

# Create a label to display the selected files
selected_files_label = tk.Label(root, text="Selected Files: None")
selected_files_label.pack()

# Create and configure the "Merge" button
merge_button = tk.Button(root, text="Merge Selected PDFs", command=merge_button_click)
merge_button.pack()

# Create and configure the "Reorder" button
reorder_button = tk.Button(root, text="Reorder Pages", command=reorder_button_click)
reorder_button.pack()

# Create and configure an entry for specifying page order
page_order_label = tk.Label(root, text="Page Order (comma-separated):")
page_order_label.pack()
page_order_entry = tk.Entry(root)
page_order_entry.pack()

# Start the main event loop
root.mainloop()
