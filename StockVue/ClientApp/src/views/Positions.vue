<template>
    <v-container fluid>
             <v-row column align-center>        
            <v-col cols="9">
                <h1>Positions {{ positions.length }}</h1>
            </v-col>
            <v-col cols="3">
                <AddPosition @addedPosition="addedPosition($event)"></AddPosition>
            </v-col>
        </v-row>
        <v-row>
            <StockPositions 
                    :items="positions" 
                    @updatedPosition="updatedPosition($event)" 
                    @deletedPosition="deletedPosition($event)" 
                    @addedPosition="addedPosition($event)" />
        </v-row>
</v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import StockPositions from '@/components/StockPositions.vue'; // @ is an alias to /src    
    import AddPosition from '@/components/AddPosition.vue'; // @ is an alias to /src    
    import { Position } from '@/store/positions/types'

    @Component({
        components: {
            StockPositions, 
            AddPosition
        },
    })
    export default class Positions extends Vue {

        public positions: Object[] = [];

        async mounted() {
            console.log("mounted");
            if (this.$store.getters['positions/positionCount'] == 0) {
                this.fetchData();                
            }
            this.positions = this.$store.getters['positions/getAll'];
        }

        public fetchData(): void {
            this.$store.dispatch("positions/loadStockPositions");
        }

        public addedPosition(data: any): void {
            console.log('added position');
            this.$store.dispatch("positions/addPosition", data);
        }

        public updatedPosition(data: Position): void {
            console.log('updated position'); 
            this.$store.dispatch("positions/updatePosition", data);
        }

        public deletedPosition(data: Position): void {
            console.log('deleted position');
            this.$store.dispatch("positions/removePosition", data);
        }
    }

</script>
